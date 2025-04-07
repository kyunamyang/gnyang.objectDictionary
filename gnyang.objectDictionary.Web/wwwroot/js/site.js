// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var App = {};
App.module = {};

App.module.objectDictionary = function () {
    var url = '';
    var selectedAlphabet;
    var models;
    var model;

    function setUrl(url) {
        this.url = url;
    }

    function getModels() {
        return this.models;
    }

    function getModel() {
        return this.model;
    }

    function getModelList(param, callback) {
        $.ajax({
            context: this,
            type: 'GET',
            url: '/api/model',
            data: 'startChar=' + param,
            success: function (arr) {
                this.models = arr;
                callback();
            },
            error: function (req, status, error) {
                alert(error);
            },
        });
    }

    function getModelDetail(id, callback) {
        $.ajax({
            context: this,
            type: 'GET',
            url: '/api/model/' + id,
            data: null,
            success: function (detail) {
                this.model = detail;
                callback();
            },
            error: function (req, status, error) {
                alert(error);
            },
        });
    }

    function getCode(param, callback) {
        var data = {
            "name": param.name,
            "fields": []
        };

        param.fields.forEach(el => {
            data.fields.push({
                "type": "string",
                "name": el.name
            }) 
        })

        var str = JSON.stringify(data);

        $.ajax({
            type: 'POST',
            url: '/api/code',
            contentType: 'application/json',
            dataType: 'text',
            data: str,
            success: function (c) {
                callback(c);
            },
            error: function (req, status, error) {
                alert(error);
            },
        });
    }

    return {
        setUrl: setUrl,
        getModels: getModels,
        getModel: getModel,

        getModelList: getModelList,
        getModelDetail: getModelDetail,
        getCode: getCode,
    }
};