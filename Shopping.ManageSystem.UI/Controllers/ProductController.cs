using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shopping.ManageSystem.BLL;
using Shopping.ManageSystem.Model;
using System.IO;
using Webdiyer.WebControls.Mvc;
using NPOI.SS.UserModel;

namespace Shopping.ManageSystem.UI.Controllers
{
    public class ProductController : Controller
    {

        //实例化ProductCategoryBLL
        ProductBLL productBLL = new ProductBLL();

        //绑定下拉
        public void Binding()
        {
            //获取数据
            List<ProductCategory> products = productBLL.Binding();
            //传输数据
            ViewBag.xia = products;
        }

        //产品名称唯一判断
        public ActionResult UniqueProductName(string ProductName)
        {
            //获取数据
            Product product = productBLL.UniqueProductName(ProductName);
            if (product!=null)
            {
                return Json(new { valid = false,Message="the message" });
            }
            else
            {
                return Json(new { valid = true, Message = "the message" });
            }
        }

        // 显示+分页+查询
        public ActionResult ProductIndex(int pageIndex=1,int pageSize=2,string productName="",int categoryID=0,string Is_Delete="")
        {
            //调用实现绑定
            Binding();
            //获取数据
            List<Product> model = productBLL.ProductShow();
            //根据名称模糊查询
            if (!string.IsNullOrEmpty(productName))
            {
                model = (from m in model where m.ProductName.Contains(productName) select m).ToList();
            }
            //根据产品分类查询
            if (categoryID!=0)
            {
                model = (from m in model where m.CategoryID.Equals(categoryID) select m).ToList();
            }

            //根据删除状态查询
            if (!string.IsNullOrEmpty(Is_Delete))
            {
                model = (from m in model where m.Is_Delete.Equals(Convert.ToBoolean(Is_Delete)) select m).ToList();
            }

            //获取数据条数
            int rCount = model.Count();

            //对数据进行分页
            List<Product> data = model.OrderBy(m => m.ProductID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

            //转换为分页数据类型
            PagedList<Product> PageData = new PagedList<Product>(data, pageIndex, pageSize, rCount);

            //判断是否为Ajax提交
            if (Request.IsAjaxRequest())
            {
                return PartialView("_PartialProduct", PageData);
            }
            return View(PageData);
        }

        //富文本图片
        public ActionResult Upload()
        {
            HttpPostedFileBase file = Request.Files[0];
            if (file.ContentLength>0&&file.FileName!=null)
            {
                //拼接图片名称
                string fname = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                //获取根目录
                string str = Server.MapPath("~/Files");
                //完整路径
                string fileName = Path.Combine(str, fname);
                //获取相对路径
                string xdPath = "/Files/"+ fname;

                //保存图片
                file.SaveAs(fileName);
                return Json(new { errno = 0, data = new string[] { xdPath } });
            }
            return Json(new { errno = 1, data = "" });
        }

        //图片上传添加
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ProductCreate(Product obj,HttpPostedFileBase productImg)
        {
            //判断文件是否上传成功
            if (productImg == null || productImg.ContentLength==0)
            {
                ModelState.AddModelError("ProductImg", "文件上传失败");
            }
            else
            {
                //拼接图片名称
                string fname = productImg.FileName;

                //获取根目录
                string str = Server.MapPath("~/Files");
                //完整路径
                string fileName = Path.Combine(str, fname);
                //获取相对路径
                string xdPath = "/Files/" + fname;

                //保存图片
                productImg.SaveAs(fileName);

                //保存到数据库
                obj.ProductImg = xdPath;

                //调用添加
                int h = productBLL.ProductCreate(obj);
                if (h>0)
                {
                    return Json(new { Code = 1, Message = "添加成功" });
                }
            }
            return Json(new { Code = 2, Message = "添加失败" });
        }


        //逻辑删除（支持批删）
        public ActionResult ProductDelete(string id)
        {
            //调用删除方法
            int h = productBLL.ProductDelete(id);
            if (h>0)
            {
                return Json(new { Code = 1, Message = "删除成功" });
            }
            else
            {
                return Json(new { Code = 0, Message = "删除失败" });
            }
        }
        //反填数据
        public ActionResult ProductEdit(int id)
        {
            Product product = productBLL.ProductEdit(id);
            if (product!=null)
            {
                return Json(new {Code=1,Data=product });
            }
            else
            {
                return Json(new {Code = 0, Data = product });
            }
        }

        //修改数据
        [ValidateInput(false)]
        public ActionResult ProductUpdate(Product obj, HttpPostedFileBase EditproductImg)
        {
            //判断文件是否上传成功
            if (EditproductImg == null || EditproductImg.ContentLength == 0)
            {
                ModelState.AddModelError("ProductImg", "文件上传失败");
            }
            else
            {
                //拼接图片名称
                string fname = Guid.NewGuid().ToString() + Path.GetExtension(EditproductImg.FileName);

                //获取根目录
                string str = Server.MapPath("~/Files");
                //完整路径
                string fileName = Path.Combine(str, fname);
                //获取相对路径
                string xdPath = "/Files/" + fname;

                //保存图片
                EditproductImg.SaveAs(fileName);

                //保存到数据库
                obj.ProductImg = xdPath;

                //获取修改时间
                obj.ProductTime = DateTime.Now;

                //获取修改方法
                int h = productBLL.ProductUpdate(obj);
                if (h > 0)
                {
                    return Json(new { Code = 1, Message = "修改成功" });
                }
            }
            return Json(new { Code = 2, Message = "修改失败" });
        }

        //下载模板
        public ActionResult ProductDownLoadFiles()
        {
            string fileName = Server.MapPath("~/Files/模板.xlsx");
            return File(fileName, "application/octet-stream", "模板.xlsx");
        }

        //导入
        public ActionResult ProductVastCreate()
        {
            //获取传入的文件
            var file = Request.Files[0];
            if (file!=null && file.ContentLength>0)
            {
                //生成工作簿
                IWorkbook workbook = WorkbookFactory.Create(file.InputStream);

                //获得工作表对象
                ISheet sheet = workbook.GetSheetAt(0);

                List<Product> data = new List<Product>();

                //循环获取每一行
                for (int i = 2; i <= sheet.LastRowNum; i++)
                {
                    //行的对象
                    IRow row = sheet.GetRow(i);

                    //获取数据
                    Product product = new Product()
                    {
                        ProductName = row.Cells[0].StringCellValue,
                        ProductPrice = Convert.ToDecimal(row.Cells[1].NumericCellValue),
                        CategoryID = (int)row.Cells[2].NumericCellValue,
                        ProductDesc = row.Cells[3].StringCellValue,
                        ProductTime = DateTime.Now,
                        Is_Delete = true
                    };

                    data.Add(product);

                }

                int h = productBLL.ProductVastCreate(data);
                if (h>0)
                {
                    return Json(new { Code = 1, Message = "导入成功" });
                }
            }
            return Json(new { Code = 2, Message = "导入失败" });
        }
    }
}