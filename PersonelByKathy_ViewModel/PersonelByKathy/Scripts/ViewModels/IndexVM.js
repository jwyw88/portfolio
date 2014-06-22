var urlPath = window.location.pathname;

function Jobs(data) {
    this.Title = ko.observable(data.Title);
    this.Description = ko.observable(data.Description);
    this.City = ko.observable(data.City);
    this.IsFullTime = ko.observable(data.IsFullTime);
}

var indexVM = {
    //Data
    Jobs: ko.observableArray([]),
    FirstName: ko.observable(''),
    LastName: ko.observable(''),
    Email: ko.observable(''),
    LoadJobs: function () {
        var self = this;
        //ajax call to grab jobs
        $.ajax({
            type: 'GET',
            url: '/Job/FillIndex',
            contentType: 'applicatoin/json; charset=utf-8',
            dataType: 'json',
            success: function (data) {
                self.Jobs(data.Jobs);
                self.FirstName(data.FirstName);
                self.LastName(data.LastName);
                self.Email(data.Email);
            },
            error: function (err) {
                alert('wtf - ' + err.status + " : " + err.statusText);
            }
        });
    }
}

$(function () {
    ko.applyBindings(indexVM);
    indexVM.LoadJobs();
});