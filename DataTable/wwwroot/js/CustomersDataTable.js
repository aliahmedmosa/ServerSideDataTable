$(document).ready(function () {
    $('#customers').dataTable({
        "serverSide": true,
        "filter": true,
        "ajax": {
            "url": "api/Customers",
            "type": "post",
            "dataType":"json"
        },
        "columnDefs": [{
            "targets": [0],
            "visable": false,
            "searchable": false
        }],
        "columns": [
            { "data": "id", "name": "Id", "autowidth": true },
            { "data": "firstName", "name": "FirstName", "autowidth": true },
            { "data": "lastName", "name": "LastName", "autowidth": true },
            { "data": "contact", "name": "Contact", "autowidth": true },
            { "data": "email", "name": "Email", "autowidth": true },
            { "data": "dateOfBirth", "name": "DateOfBirth", "autowidth": true },
            {
                "render": function (data, type, row) { return '<a href="#" class="btn btn-danger " onclick=deletecustomer("' + row.id + '");>Delete</a> ' }
                , "orderable": false
            }
            
        ]
    });
});