var _dataTable;

$(document).ready(function () {
    wireUpDataTable();
    wireUpInputs();
});


function wireUpDataTable() {
    _dataTable = $('#comic-book-series-table').DataTable({
        'ajax': {
            'url': $('#Get_getCurrentComicBookSeriesURL').val(),
            'type': 'POST',
            'data': function (d) {
                d.publisherId = $('#PublisherSelectList').val();
            }
        },
        'columns': [
            { 'data': 'PublisherName' },
            { 'data': 'ComicBookSeriesTitle' }
        ]
    })
}

function wireUpInputs() {
    $('#PublisherSelectList').change(bindData);
}

function bindData() {
    _dataTable.ajax.reload();
}