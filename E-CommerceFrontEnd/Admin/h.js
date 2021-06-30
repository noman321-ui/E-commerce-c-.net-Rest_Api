$.ajax({
    url: 'http://localhost:49274/api/admin/AddProduct',
    method:"POST",
    headers:"Content-Type:application/json",
    enctype: 'multipart/form-data',
    type: 'POST',
    data: data,
    cache: false,
    processData: false,
    contentType: false,
    complete: function (xmlHttp,status) {
        if(xmlHttp.status == 201){
                var data = xmlHttp.responseJSON;
                alert(data);
            }
    },
    error: function () {
        alert('Error occured');
    }
});