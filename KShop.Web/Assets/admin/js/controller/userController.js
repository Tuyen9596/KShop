/// <reference path="E:\GitHub\Project Visual 2012\C #\ASP.NET\KShop_Web\KShop.Web\Content/Common/js/jquery-3.3.1.js" />
var user = {
    init: function () {
        user.registerEvents();
    },
    registerEvents: function () {
        $('.btn-active').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            $.ajax({
                url:"/admin/User/ChangeStatus",
                data: { id: id },
                dataType: "json",
                type:"POST",
                success: function (response) {
                    console.log(response);
                    if (response.Status == true) {
                        btn.text('Active')
                    } else
                        btn.text('No-Active')
                }
            });
        });
    }
}
user.init();