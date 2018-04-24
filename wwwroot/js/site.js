function postAjax(url, data) {
    const token = $('input[name=__RequestVerificationToken]').val();
    const header = {};

    header['RequestVerificationToken'] = token;
    
    $.ajax({
        url: url,
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(data),
        headers: header
    })
}