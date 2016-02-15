$(document).ready(function () {
    wireUpDataTable();
});

function wireUpDataTable() {
    $('#SubscriptionTable').DataTable({
        ordering: false,
        info: false
    });
}