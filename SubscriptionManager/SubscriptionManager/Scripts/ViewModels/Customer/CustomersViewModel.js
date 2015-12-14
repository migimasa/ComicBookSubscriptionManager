function CustomersViewModel(customers) {
    var self = this;

    self.customers = customers;

    self.showModifyModal = function (data, event) {
        self.sending = ko.observable(false);

        $.get($(event.target).attr('href'), function (d) {
            $('.body-content').prepend(d);
            $('#modifyModal').modal('show');

            ko.applyBindings(self, document.getElementById('modifyModal'));
        });
    }

    self.saveCustomer = function (form) {
        self.sending(true);
        return true;
    };
}