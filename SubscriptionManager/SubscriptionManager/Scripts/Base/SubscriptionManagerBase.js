function displayAlert(displayOptions) {
    var baseOptions = {
        height: 200,
        width: 400,
        resizable: false,
        modal: true,
        onClose: null,
        title: '',
        closeOnEscape: true,
        html: '',
        buttons: null
    }

    var options = $.extend({}, baseOptions, displayOptions);

    $('#alertDialog').html(options.html);

    $('#alertDialog').dialog({
        autoOpen: true,
        closeOnEscape: true,
        width: options.width,
        height: options.height,
        modal: options.modal,
        title: options.title,
        close: function () { if (options.onClose != null) { options.onClose(); } },
        buttons: options.buttons
    });
}

function closeAlert() {
    $('#alertDialog').dialog('close');
    $('#alertDialog').html('');
}