/// <reference path="E:\GitHub\Project Visual 2012\C #\ASP.NET\KShop_Web\KShop.Web\Content/Common/js/jquery-3.3.1.js" />
var user = {
    init: function () {

    },
    rehisterEvents: function () {
        $('.btn-active').off('click').on('click', function (e) {
            e.preventDefault();
            var id = $(this).data('ID');
            $.ajax({
                url: "/User/ChangeStatus",
                data: { id: id },
                type: "json",
                contentType: "application/json;charset=utf-8",
                success: function (response) {
                    console.log(response);
                    if (response.Status == true) {
                        $(this).text('Active')
                    } else $(this).text('No-Active')
                }
            });
        });
    }
}