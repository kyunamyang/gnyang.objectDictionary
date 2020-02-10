// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var App = {};
App.module = {};

App.module.objectDictionary = function () {
    var url = '';
    var selectedAlphabet;
    var models;

    function setUrl(url) {
        this.url = url;
    }

    function getCurrentAlphabet() {
        return $('.selectedAlphabet').innerText;
    }

    function getModels() {
        return this.models;
    }

    function setModels(m) {
        this.models = m;
    }

    function getAll(callback) {
        $.ajax({
            context: this,
            type: 'GET',
            url: '/api/model',
            data: '',
            success: function (data) {
                this.setModels(data);
                callback();
            },
            error: function (req, status, error) {
                alert(error);
            },
        });
        
    }

    return {
        setUrl: setUrl,
        getModels: getModels,
        setModels: setModels,
        getAll: getAll,
    }
};