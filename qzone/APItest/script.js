$(function () {
    $(".post").click(function () {
        //send post ajax
        var url = $(".postUrl").val();
        var params = $(".postParmas").val();
        $.ajax({
            url: url,
            type: 'POST', //GET
            async: true,    //或false,是否异步
            data: splitParams(params),
            success: function (data) {
                console.log("getResponse:"+data);
                $('.callback-post').val(data);
            }
        });
    });
    
    $(".get").click(function () {
        //send get ajax
        var url = $(".getUrl").val();
        $.ajax({
            url: url,
            type: 'GET', //GET
            async: true,    //或false,是否异步
            success: function (data) {
                console.log("postResponse:" + data);
                $('.callback-get').val(data);
            }
        });
    });


    //处理参数返回JSON,作为post参数
    function splitParams(params){
        var paramsArr = params.split('&');
        var ans = {};
        for (var i = 0; i < paramsArr.length; i++) {
            var str = paramsArr[i].split('=');
            ans[str[0]] = str[1];
        }
        return ans;
    }

});