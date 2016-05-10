function LibraryViewModel(library) {
    var self = this;

    self.library = library;
    self.subscriptions = library.subscriptions;

    self.showManageLibraryScreen = function (data, event) {
        var s = '';
    }

    self.removeSubscription = function (comicBookSeries, event) {

        if (confirmRemovalByUser(comicBookSeries.comicBookSeriesTitle)) {
            postToRemoveComicBookSeries(comicBookSeries);
        }
    }
}

function getSuccessAlertHtml(comicBookSeriesTitle) {
    var html = '';

    html += '<div class="alert alert-dismissible alert-success" role="alert">';

    html += '    <button type="button" class="close" data-dismiss="alert">&times;</button>';
    html += '    You have successfully removed <strong>' + comicBookSeriesTitle + '</strong>.'
    html += '</div>';

    return html;
}

function confirmRemovalByUser(comicBookSeriesTitle) {

    if (confirm('Are you sure you would like to remove ' + comicBookSeriesTitle + '?')) {
        return true;
    }
    return false;
}

function postToRemoveComicBookSeries(comicBookSeries) {
    var removePostUrl = $('#RemoveSubscriptionURL').val();

    var postData = {
        customerId: comicBookSeries.customerId,
        subscriptionId: comicBookSeries.customerSubscriptionId
    }

    $.ajax({
        url: removePostUrl,
        type: 'POST',
        data: postData,
        success: function (removeResult) {
            location.reload();
        }
    });
}