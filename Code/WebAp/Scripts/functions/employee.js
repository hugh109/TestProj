
function formInit() {

    console.log(1);
    eventSetting();
}

function eventSetting() {
    console.log("eventSetting");
    $("#btnQuery").on("click", dataTable);
}

function dataTable() {
    $('#DataList').DataTable({
        "ajax": config.url.getEmployees
    });
}

function showList() {
    var _url = config.url.getEmployees;
    var _data = {
        page: { pageSize: 5, pageIndex: 0 },
        data: {id:0}
    };
    $.post(_url, _data,function (result) {
        console.log(result);
    });
}