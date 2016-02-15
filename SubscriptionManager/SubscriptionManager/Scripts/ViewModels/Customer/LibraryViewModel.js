function LibraryViewModel(library) {
    var self = this;

    self.library = library;
    self.subscriptions = library.subscriptions;

    self.showAddSubscriptionModal = function (data, event) {
        self.sending = ko.observable(false);

        $.get($(event.target).attr('href'), function (d) {
            $('.body-content').prepend(d);
            $('#').modal('show');

            ko.applyBindings(self, document.getElementById(''));
        });
    }

    self.removeSubscription = function (comicBookSeries, event, temp, temp2, temp3) {
        var removePostUrl = $('#RemoveSubscriptionURL').val();

        var postData = {
            customerId: comicBookSeries.customerId,
            comicBookSeriesId: comicBookSeries.comicBookSeriesId
        }

        $.ajax({
            url: removePostUrl,
            type: 'POST',
            data: postData,
            success: function (removeResult) {
                var alertHtml = getAlertHtml(comicBookSeries.comicBookSeriesTitle);

                $('#alert-div').html(alertHtml);

                $('#alert-div').show();
            }
        });

        //library contains customerId, comicBookSeriesId

        //write ajax post to remove subscription




    }
}

function getAlertHtml(comicBookSeriesTitle) {
    var html = '';

    html += '<div class="alert alert-dismissible alert-success" role="alert">';

    html += '    <button type="button" class="close" data-dismiss="alert">&times;</button>';
    html += '    You have successfully removed <strong>' + comicBookSeriesTitle + '</strong>.'
    html += '</div>';

    return html;
}

function temp(comicBookSeriesTitle) {
    var html = '';

    html += '<div class="modal">';
    html += '<div class="modal-dialog'


    html += '</div>';

    return html;
}