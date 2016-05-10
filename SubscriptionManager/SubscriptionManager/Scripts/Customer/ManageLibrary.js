var dataTable;

$(document).ready(function () {
    wireUpDataTable();
    wireUpInputs();
    wireUpTableButtons();
});

function wireUpTableButtons() {
    $('td').on('click', '.add-button', function () {
        //e.preventDefault();

        //var seriesId = $(this).data('series-id');

        //postToAddSubscription(seriesId);

        alert("button clicked");
    });

    $('table').on('click', '.remove-button', function (e) {
        e.preventDefault();

        var subscriptionId = $(this).data('subscription-id');

        postToRemoveSubscription(subscriptionId);
    });

    $('table').on('click', '.add-button', function (e) {
        e.preventDefault();

        var seriesId = $(this).data('series-id');

        postToAddSubscription(seriesId);
    });
}

function wireUpDataTable() {
    _dataTable = $('#comic-book-series-table').DataTable({
        'ajax': {
            'url': $('#Get_getManageLibraryDataURL').val(),
            'type': 'POST',
            'data': function (d) {
                d.publisherId = $('#PublisherSelectList').val();
                d.customerId = $('#CustomerId').val();
            }
        },
        'initComplete': function(settings, json) {
            


            //$('.add-button').click(function (e) {
            //    var seriesId = $(this).data('series-id');


            //    postToAddSubscription(seriesId);
            //});

            //$('.remove-button').click(function () {
            //    var subscriptionId = $(this).data('subscription-id');

            //    postToRemoveSubscription(subscriptionId);
            //});

        },
        'columns': [
            { 'data': 'SeriesTitle' },
            {
                'data': function (comicBookSeries) {
                    var html = '';

                    var htmlClasses = 'btn btn-primary add-button';
                    var buttonText = "Add";

                    if (comicBookSeries.IsSubscribed) {
                        htmlClasses = 'btn btn-danger remove-button';
                        buttonText = "Remove";
                    }

                    html = '<button data-series-id="' + comicBookSeries.SeriesId + '" data-subscription-id="' + comicBookSeries.SubscriptionId + '" class="' + htmlClasses + '">' + buttonText + '</button>';

                    return html;
                }
            }
        ]
    });
}

function wireUpInputs() {
    $('#PublisherSelectList').change(bindData);
}

function bindData() {
    _dataTable.ajax.reload();
}

function postToAddSubscription(seriesId) {
    
    var postItem = {
        customerId: $('#CustomerId').val(),
        comicBookSeriesId: seriesId
    }

    var postUrl = $('#AddSubscriptionPostUrl').val();

    $.post(postUrl, postItem, function (data, status) {
        if (data != null) {
            if (data.IsSuccess) {
                bindData();
            }
        }
    });
}

function postToRemoveSubscription(subscriptionId) {
    var postItem = {
        customerId: $('#CustomerId').val(),
        subscriptionId: subscriptionId
    }

    var postUrl = $('#RemoveSubscriptionPostUrl').val();

    $.post(postUrl, postItem, function (data, status) {
        if (data != null) {
            if (data.IsSuccess) {
                bindData();
            }
        }
    });
}