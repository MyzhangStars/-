(function(){
    //设置主框架初始化高度
   window.onload=function()
   {

         const headerHeight=89;
         const footHeight=45;
         let getHeight=$(document).height();
         var getRealHegiht=getHeight-headerHeight;
         $(".contentCenter").height(getRealHegiht-footHeight);
         //动态设置左侧菜单的高
         $(".menuLeft").height(getRealHegiht);
         //#region 1111
       //设置菜单选中时事件
        $(".menuLeft ul li").click(function(){
     
              $(this).addClass("active").siblings().removeClass("active");
              $("#iframeShow").attr("src",$(this).attr("href"));

         });
           //#endregion
   }



})()