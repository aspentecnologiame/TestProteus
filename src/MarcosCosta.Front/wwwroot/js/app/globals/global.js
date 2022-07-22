(function () {

    'use etrict';

    return global = {
        BaseUrl: '/',
        BaseApiUrl: 'api/',
        CreateRequest: createRequest
    };

    function createRequest(url, verb, data) {

        var headers = {
            'Content-type': 'application/json;charset=utf-8'
        };

        if (data === undefined) {

            return {
                url: global.BaseApiUrl + url,
                method: verb,
                headers: headers
            }

        }
        else {

            return {
                url: global.BaseApiUrl + url,
                method: verb,
                data: {
                    Token: localStorage.getItem('token'),
                    Data: data
                },
                headers: headers
            }
        }
    }

})();