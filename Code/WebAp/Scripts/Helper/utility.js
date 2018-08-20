/*
*顯示/關閉 凍結子視窗 
*/
function ShowBlock(/*ex: "#showArea"*/_div, _msg, _isShow, _width) {
    var _css = {
        padding: '2px', '-webkit-border-radius': '4px', '-moz-border-radius': '4px', 'border-radius': '4px',
        border: '1px solid rgb(64, 100, 195)',
        'border-top': '0px solid rgb(66, 103, 197)',
        'box-shadow': '3px 3px 4px rgba(25,25,25,0.5)'
    };
    if (_width) {
        //_width = _width || "50%";
        _css.width = _width;
    }

    if (_div != "" & _div != null) {
        if (_isShow) {
            $(_div).block({ message: _msg, css: _css });

        } else {
            $(_div).unblock();
        }
    } else {
        if (_isShow) {
            $.blockUI({ message: _msg, css: _css });
            $('.blockUI.blockMsg').center();
        } else {
            $.unblockUI();
        }
    }
}

function showConfirmMessageBox(msg, YesfunctionName, NofunctionName) {
    $("#modalConfirmLabel").html(msg)
    ShowBlock(null, $('#modalConfirm'), true);
    $("#btnModalYes,#btnModalNo").off("click");
    if (jQuery.type(YesfunctionName) === "function") {
        $("#btnModalYes").on("click", YesfunctionName);
    }
    if (jQuery.type(NofunctionName) === "function") {
        $("#btnModalNo").on("click", NofunctionName);
    }
}

$.fn.center = function () {
    this.css("position", "absolute");
    this.css("top", ($(window).height() - this.height()) / 2 + $(window).scrollTop() + "px");
    this.css("left", ($(window).width() - this.width()) / 2 + $(window).scrollLeft() + "px");
    return this;
}
//顯示指定字串在 browser console
var log = function (d) {
    try {
        console.log("log=>", d);
    } catch (e) { }
};

//字串組合用
String.format = function () {

    if (arguments.length == 0) {
        return null;
    }

    var str = arguments[0];

    for (var i = 1; i < arguments.length; i++) {

        var re = new RegExp('\\{' + (i - 1) + '\\}', 'gm');
        str = str.replace(re, arguments[i]);
    }
    return str;
};

String.formats = function () {

    if (arguments.length == 0) {
        return null;
    }

    var str = arguments[0];
    var _pars = arguments[1];
    for (var i = 0; i < _pars.length; i++) {

        var re = new RegExp('\\{' + (i) + '\\}', 'gm');
        str = str.replace(re, _pars[i]);
    }
    return str;
};


// 擴充Date.Format方法
// (new Date()).Format("yyyy-MM-dd hh:mm:ss.S") ==> 2006-07-02 08:09:04.423 
// (new Date()).Format("yyyy-M-d h:m:s.S")      ==> 2006-7-2 8:9:4.18 
Date.prototype.Format = function (fmt) { //author: meizz 
    var o = {
        "M+": this.getMonth() + 1, //月份 
        "d+": this.getDate(), //日 
        "h+": this.getHours(), //小时 
        "m+": this.getMinutes(), //分 
        "s+": this.getSeconds(), //秒 
        "q+": Math.floor((this.getMonth() + 3) / 3), //季度 
        "S": this.getMilliseconds() //毫秒 
    };
    if (/(y+)/.test(fmt)) fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var k in o)
        if (new RegExp("(" + k + ")").test(fmt)) fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
    return fmt;
};

//字串補空白
function pad(_str, _len, _pad, _dir) {

    var STR_PAD_LEFT = "1";
    var STR_PAD_RIGHT = "2";
    var STR_PAD_BOTH = "3";

    if (typeof (_len) == "undefined") { _len = 0; }
    if (typeof (_pad) == "undefined") { _pad = ' '; }
    if (typeof (_dir) == "undefined") { _dir = STR_PAD_RIGHT; }
    var _result = "";
    if (_len + 1 >= _str.length) {

        switch (_dir) {

            case STR_PAD_LEFT:
                _result = Array(_len + 1 - _str.length).join(_pad) + _str;
                break;

            case STR_PAD_BOTH:
                //Round是四舍五入的。。。Ceiling是向上取整。。float是向下取整
                var right = Math.ceil((padlen = _len - _str.length) / 2);
                var left = padlen - right;
                _result = Array(left + 1).join(_pad) + _str + Array(right + 1).join(_pad);
                break;

            default:
                _result = _str + Array(_len + 1 - _str.length).join(_pad);
                break;

        } // switch
    }
    return _result;
}

//千分位效果
function toUum(num) {
    num = num + "";
    var re = /(-?\d+)(\d{3})/
    while (re.test(num)) {
        num = num.replace(re, "$1,$2")
    }
    return num;
}

function sleep(seconds) {
    var timer = new Date();
    var time = timer.getTime();
    do
        timer = new Date();
    while ((timer.getTime() - time) < (seconds * 1000));
}

function showTimeLog(_msg) {
    var _now = new Date();
    console.log(String.format("{0}:{1}", _now, (_msg || "")));
}
