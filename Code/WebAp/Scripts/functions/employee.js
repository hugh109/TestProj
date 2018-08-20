
function formInit() {
    eventSetting();
    fetchPageInit();

    refreshPage();
}

function eventSetting() {
    var _divId = "resultArea";
    $("#btnNew").on("click", updateData);
    $(document).on("click", "#" + _divId + " .btnEdit", updateData);
    $(document).on("click", "#" + _divId + " .btnDel", delData);
}

function refreshPage() {
    var _page = window.location.hash ? window.location.hash.slice(1) : 1;

    fetchPage(_page);
}
function fetchPage(page) {
    var _url = config.url.getEmployees;
    var _data = { page: page };
    $.post(_url, _data, function (result) {
        window.location.hash = page;
        $("#resultArea").html(result);
    });
}

function fetchPageInit() {
    var _div = "#resultArea";
    var _objs = String.format("{0} .pagination li a", _div);
    $(document).on("click", _objs, function (event) {
        var _this = $(this);
        var _replaceStr = String.format("{0}?Index=", config.url.getEmployees);
        var _hyperLinkUrl = _this.attr("href");
        if (typeof _hyperLinkUrl !== "undefined" && _hyperLinkUrl !== false) {
            var _pageNumber = _this.attr("href").replace(_replaceStr, "");
            //event.preventDefault();
            fetchPage(_pageNumber);
            //console.log(_pageNumber);
            return false;
        }
    })
}

//-------------------------------------------

function updateData() {
    var _this = $(this);
    var _id = _this.parent().parent().data("id");
    var _url = String.format("{0}/{1}", config.url.detail, _id);
    location.href = _url
}

function delData() {
    var _this = $(this);
    var _id = config.data.selectID = _this.parent().parent().data("id");
    var _label = _this.parent().parent().data("label");
    console.log("del:" + _id, _label);

    var _msg = String.format("確定要刪除此筆資料?<br>{0}?", _label);

    $("#modalConfirmLabel").html(_msg)
    ShowBlock(null, $('#modalConfirm'), true);
    showConfirmMessageBox(_msg, function () {
        var _url = config.url.del;
        var _data = { id: config.data.selectID };
        $.post(_url, _data, function (result) {

            if (result.Success == true) {
                _msg = "刪除完成.";
                refreshPage();
            } else {
                console.log(result.Msg);
                _msg = "儲存異常,請重新操作."
            }
            showMsg(_msg);
        });
    }, function () {
        ShowBlock();
    });

}

function showMsg(msg) {
    ShowBlock(null, msg, true);

    setTimeout(function () {
        ShowBlock();
    }, 2000);

}