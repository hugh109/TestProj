
function formInit() {
    eventSetting();
    
}

function eventSetting() {
    var _divId = "resultArea";
    $("#btnBackList").on("click", backIndex);
    $("#btnSave").on("click", updateData);

    $("#BirthDate").datepicker({ dateFormat: 'yy/mm/dd', maxDate: "-1d" });
}

function backIndex() {
    location.href = config.url.index;
}


function updateData() {
    var _this = $(this);
    var _url =  config.url.update

    //var _data = JSON.stringify($("#modifyArea").serialize());
    var _data = $("#modifyArea").serialize();
   
    $.post(_url, _data, function (result) {
        if (result.Success == true) {
            _msg = "儲存完成.";
        } else {
            _msg = result.Msg;
        }
       
        ShowBlock(null, _msg, true);

        setTimeout(function () {
            ShowBlock();
        }, 2000);
    });
}
