$.browser = {};

$.browser.mozilla = /firefox/.test(navigator.userAgent.toLowerCase());
$.browser.webkit = /webkit/.test(navigator.userAgent.toLowerCase());
$.browser.opera = /opera/.test(navigator.userAgent.toLowerCase());
$.browser.msie = /msie/.test(navigator.userAgent.toLowerCase());

var cookiedomain = isUndefined(cookiedomain) ? '' : cookiedomain;
var cookiepath = "/";

function unajax() {
}

function isUndefined(variable) {
    return typeof variable == 'undefined' ? true : false;
}

function msg(_msg, _url) {
    var _url = _url || "";
    var cancel_fn = function () { window.location.href = _url; };
    
    var dlg = new dialog({ cache: 0, title: 'Notice', body: _msg, mode: 'notice',yes:{ title: "OK", events: function () {} }});
    if (_url == "")
    {
        dlg.show();
    }
    else
    {
        dlg.show({ onHide: cancel_fn, mode: 'notice', yes: { title: 'OK', events: cancel_fn}});
    }
}

//返回上一级 包含 style = z-index 的 DOM
function findPrevZindex(id)
{
    return $('#' + id).parents('[style*=z-index]:first');
}

function HTMLEnCode(str) {
    var s = "";
    if (str.length == 0) return "";
    s = str.replace(/&/g, "&gt;");
    s = s.replace(/</g, "&lt;");
    s = s.replace(/>/g, "&gt;");
    s = s.replace(/[ ]/g, "&nbsp;");
    s = s.replace(/\'/g, "'");
    s = s.replace(/\"/g, "&quot;");
    s = s.replace(/\n/g, "<br />");
    return s;
}

function HTMLDeCode(str) {
    var s = "";
    if (str.length == 0) return "";
    s = str.replace(/&gt;/g, "&");
    s = s.replace(/&lt;/g, "<");
    s = s.replace(/&gt;/g, ">");
    s = s.replace(/&nbsp;/g, " ");
    s = s.replace(/'/g, "\'");
    s = s.replace(/&quot;/g, "\"");
    s = s.replace(/<br \/>/g, "\n");
    return s;
}

function parseObj(strData) {
    return (new Function("return " + strData))();
}

function parseJqueryToObj($o) {
    var obj = {};

    if (typeof ($o) == 'undefined') {
        return obj;
    }
    $o.each(function () {
        if (jQuery(this).val() != "") {
            obj[jQuery(this).attr('name')] = jQuery(this).val();
        }
    });
    return obj;
}


function ReplaceStrToScript(str) {
    if (str != null)
        return str.replace(/[\\]/g, "\\\\").replace(/[']/g, "\\'").replace(/[\"]/g, "\\\"").replace(/[\n]/g, "\\n");
    else
        return "";
}

function GetID(str) {
    if (str == null)
        return "";
    else
        return escape(str).replace(/[ !@#$%^&*()]/g, "");
}

// url = DeleteUrlParameter(url, "rt") + "rt=" + encodeURIComponent(rt);
// ext  default:1  (0,1  0为不带连接符，1为带连接符)
function DeleteUrlParameter(url, P, ext) {

    var para = "[^\\?&=]*";

    var pattern2 = new RegExp("&" + P + "=" + para + "(?=&.|\\b)", "gi");
    url = url.replace(pattern2, "");

    var pattern1 = new RegExp("\\?" + P + "=" + para + "(&|\\b)?", "gi");
    url = url.replace(pattern1, "?");

    url = url.replace(/[\?&]+$/g, "");// delete ?& in the end

    ext = isUndefined(ext) ? '1' : ext;

    if (ext == '1') {
        if (/^[^?]*\?[^?]*[^\?&]$/g.test(url)) {//check ?
            return url + "&";
        }
        else {
            return url + "?";
        }
    }
    else
        return url;
}

function SuccessOpenDialog(data, status) {
    var url = this.getAttribute("data-ajax-url") || this.getAttribute("href") || '';
    var t = decodeURI(getParam(url, "t")).replace(/[+]/gi, ' ');
    if (t == "") t = this.getAttribute("data-title") || '';
    var cover = getParam(url, "cover");
    if (cover != "1") cover = this.getAttribute("data-cover");

    showDialogOption({ msg: data, t: t, mode: "dialog", cover: cover * 1, k: this.k });
}

function FailureOpenDialog(xhr, status, error) {
    return;
}

function dialog_close() {
    var dlgid = jQuery(this).parent("div.fwinmask").attr('id');
    dlgid = dlgid || jQuery(this).parents("div.modal:first").attr('id');
    hideMenu(dlgid, 'dialog');
}

function getFunction(code, argNames) {
    var fn = window, parts = (code || "").split(".");
    while (fn && parts.length) {
        fn = fn[parts.shift()];
    }
    if (typeof (fn) === "function") {
        return fn;
    }
    argNames.push(code);
    return Function.constructor.apply(null, argNames);
}

//k       default:'' 你懂的
//msg     default:'' 显示内容
//cover   default:'' 覆盖
function loadding(op) {
    var l = new Object();
    op = op || {};
    l.k = isUndefined(op['k']) ? '' : op['k'];
    l.cover = isUndefined(op['cover']) ? '' : op['cover'];
    l.msg = isUndefined(op['msg']) ? '' : op['msg'];

    l.loadingst = null;

    l.load = function () {
        loadingst = setTimeout(function () { showDialogOption({ k: l.k, msg: l.msg, mode: 'info', t: '<img src="' + IMGDIR + '/loading.gif"> 请稍候...', func: '', cover: l.cover }) }, 500);
    };

    l.unload = function () {
        clearTimeout(l.loadingst);
        hideMenu('fwin_dialog' + l.k, 'dialog');
    };

    return l;
}

//TODO： 待修改中....
//win_dblclick([{key:'key':value:'key value'},{key:'key':value:'key value'}], 'wink')
//DEMO:    string ajaxtarget = XUtils.get_AjaxTarget();
//         string k = XUtils.get_fwin_ShowID();
//         ondblclick="win_dblclick([{key:'@Ajax.JavaScriptStringEncode(k)',value:'@Ajax.JavaScriptStringEncode(item.PartNumber)'}])">
function win_dblclick(op, wink) {

    if (isUndefined(op)) return;
    wink = isUndefined(wink) ? '' : trim(wink);
    var total = 0;
    for (var i = 0; i < op.length; i++) {
        if (!isUndefined(op[i]["key"]) && trim(op[i]["key"]) != "" &&
            !isUndefined(op[i]["value"]) && trim(op[i]["value"]) != "") {
            var key = op[i]["key"];
            var val = op[i]["value"];

            if ($$(key)) {
                total++;
                $$(key).value = val;
            }
        }
    }
    if (total > 0) hideWindow(wink);
}

function getParam(url, key) {
    url = isUndefined(url) ? '' : url;
    key = isUndefined(key) ? '' : key;
    var reg = new RegExp("[\\?&]" + key + "=([^&]+)(\\s|&|$)", "g");
    var rst = reg.test(url);
    if (rst)
        return RegExp.$1;
    else
        return '';
}

//添加Url参数
function addparamstr(url, str) {
    url = isUndefined(url) ? '' : url;
    str = isUndefined(str) ? '' : str;
    if (url == '' || str == '') return url;
    url += (url.indexOf('?') != -1 ? '&' : '?') + str;
    return url;
}

//添加Url参数
function addparam(url, key, val) {
    url = isUndefined(url) ? '' : url;
    key = isUndefined(key) ? '' : key;
    val = isUndefined(val) ? '' : val;
    if (url == '') return url;
    if (url != '' && (key == '' || val == ''))
        return url;
    var reg = new RegExp('[&?][ ]{0,}=[ ]{0,}' + key, "g");
    url = url.replace(reg, '');
    url += (url.indexOf('?') != -1 ? '&' : '?') + '=' + val;
    return url;
}

function getRequestBody(oForm) {
    var aParams = new Array();
    for (var i = 0 ; i < oForm.elements.length; i++) {
        /*
		if (oForm.elements[i].type == "checkbox" && oForm.elements[i].checked == false)
		{continue;}
		*/
        if (oForm.elements[i].name != '' && oForm.elements[i].value != '') {
            var sParam = encodeURIComponent(oForm.elements[i].name);
            sParam += "=";
            sParam += encodeURIComponent(oForm.elements[i].value);
            aParams.push(sParam);
        }
    }
    return aParams.join("&");
}

function ajaxwait_hide() {
    jQuery("#ajaxwait").hide();
}

function ajaxwait_show() {
    jQuery("#ajaxwait").show();
}

function isint(str) {
    str = isUndefined(str) ? '' : str;
    var r = new RegExp("^-?\\d+$");
    return r.test(str);
}

function isnumber(str) {
    str = isUndefined(str) ? '' : str;
    var r = new RegExp("^-?\\d+\\.?\\d*$");
    return r.test(str);
}

//dt: /Date(1405008000000)/
//format: 扩展参数，暂时未扩展
//return yyyy-MM-dd
function datetimestrformat(dt, format) {
    try
    {
        if (isNullOrEmpty(dt)) return "";
        var mydatetime = null;

        if (typeof (dt) == "string")
            mydatetime = eval('new ' + dt.replace(/[/]/g, ''));
        else
            mydatetime = dt;

        return datetimeformat(mydatetime, format);
    }
    catch(e)
    {
        return dt;
    }
}

function datetimeformat(mydatetime, format) {
    format = isUndefined(format) ? 'yyyy-MM-dd' : format;
    var o = {
        "M+": (mydatetime.getMonth() + 1), //month
        "d+": mydatetime.getDate(), //day
        "h+": mydatetime.getHours(), //hour
        "m+": mydatetime.getMinutes(), //minute
        "s+": mydatetime.getSeconds(), //second
        "q+": Math.floor((mydatetime.getMonth() + 3) / 3), //quarter
        "S": mydatetime.getMilliseconds() //millisecond
    }
    if (/(y+)/.test(format)) {
        format = format.replace(RegExp.$1, (mydatetime.getFullYear() + "").substr(4 - RegExp.$1.length));
    }
    for (var k in o) {
        if (new RegExp("(" + k + ")").test(format)) {
            format = format.replace(RegExp.$1, RegExp.$1.length == 1 ? o[k] : ("00" + o[k]).substr(("" + o[k]).length));
        }
    }
    return format;
}

function Levenshtein_Distance(s, t) {
    var n = s.length;// length of s
    var m = t.length;// length of t
    var d = [];// matrix
    var i;// iterates through s
    var j;// iterates through t
    var s_i;// ith character of s
    var t_j;// jth character of t
    var cost;// cost

    // Step 1

    if (n == 0) return m;
    if (m == 0) return n;

    // Step 2

    for (i = 0; i <= n; i++) {
        d[i] = [];
        d[i][0] = i;
    }

    for (j = 0; j <= m; j++) {
        d[0][j] = j;
    }

    // Step 3

    for (i = 1; i <= n; i++) {

        s_i = s.charAt(i - 1);

        // Step 4

        for (j = 1; j <= m; j++) {

            t_j = t.charAt(j - 1);

            // Step 5

            if (s_i == t_j) {
                cost = 0;
            } else {
                cost = 1;
            }

            // Step 6

            d[i][j] = Minimum(d[i - 1][j] + 1, d[i][j - 1] + 1, d[i - 1][j - 1] + cost);
        }
    }

    // Step 7

    return d[n][m];
}

//求三个数字中的最小值
function Minimum(a, b, c) {
    return a < b ? (a < c ? a : c) : (b < c ? b : c);
}

function Levenshtein_Distance_Percent(s, t) {
    var l = s.length > t.length ? s.length : t.length;
    var d = Levenshtein_Distance(s, t);
    return (1 - d / l).toFixed(4);
}

function deepClone(obj) {
    return jQuery.extend(true, {}, obj);
}

function debugprint(o)
{
    if (jQuery.browser.safari || jQuery.browser.webkit)
        console.info(o);
}

//ie8++ add wbr for break word
function addbreakwrodhtml(chr, len) {
    var returnstr = '';
    while (chr.length > len) {
        var tmp = chr.substr(0, len);
        chr = chr.substr(len);
        returnstr += tmp + "<wbr>";
    }
    returnstr += chr;
    return returnstr;
}

function accMul(arg1, arg2) {
    var m = 0, s1 = arg1.toString(), s2 = arg2.toString();
    try { m += s1.split(".")[1].length } catch (e) { }
    try { m += s2.split(".")[1].length } catch (e) { }
    return Number(s1.replace(".", "")) * Number(s2.replace(".", "")) / Math.pow(10, m);
}

function accDiv(arg1, arg2) {
    var t1 = 0, t2 = 0, r1, r2;
    try { t1 = arg1.toString().split(".")[1].length } catch (e) { }
    try { t2 = arg2.toString().split(".")[1].length } catch (e) { }
    with (Math) {
        r1 = Number(arg1.toString().replace(".", ""));
        r2 = Number(arg2.toString().replace(".", ""));
        return (r1 / r2) * pow(10, t2 - t1);
    }
}

//移除数组
function removeByValue(arr, val) {
    if (isUndefined(arr) || arr == null) return [];
    for (var i = 0; i < arr.length; i++) {
        if (arr[i] == val) {
            arr.splice(i, 1);
            break;
        }
    }
    return arr;
}

function isFunction(variable) {
    return typeof variable == 'function' ? true : false;
}

//不等于空字符串，或者Null，或者未定义
function isNullOrEmpty(s) {
    return (isUndefined(s) || s == null || s === "");
}

// Common
function getDate(addDay) {
    var date = new Date();

    if (typeof (addDay) != "undefined" && !isNaN(addDay)) {
        date.setDate(date.getDate() + addDay);
    }

    // year, yyyy
    var year = date.getFullYear();

    // Month, 0 - 11
    var month = date.getMonth() + 1;
    month = month < 10 ? "0" + month : month;

    // Day, 1 - 31
    var day = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();

    return year + "-" + month + "-" + day;
}

function setIframeHeight(iframeid) {
    if (!isNullOrEmpty(iframeid)) {
        var iframeWin = $$(iframeid).contentWindow || $$(iframeid).contentDocument.parentWindow;
        if (iframeWin.document.body) {
            var height = iframeWin.document.documentElement.scrollHeight || iframeWin.document.body.scrollHeight;
            $('#'+iframeid).css('height', height + 'px');
        }
    }
};