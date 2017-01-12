

$(document).ready(function () {
    if ('@ViewBag.Message' == 'Sent') {
        alert('Mail has been sent successfully');
    }

    //$('#summernote').summernote({
    //    toolbar: [
    //      // [groupName, [list of button]]
    //      ['style', ['bold', 'italic', 'underline']],
    //      ['font', ['strikethrough', 'superscript', 'subscript']],
    //      ['fontsize', ['fontsize']],
    //      ['color', ['color']],
    //      ['para', ['ul', 'ol', 'paragraph']],
    //      ['insert', ['hr']],
    //      ['misc', ['codeview', 'undo', 'redo']]
    //    ]
    //});

});

$(function () {
    $('#datetimepicker1').datetimepicker({
        format: 'DD/MM/YYYY hh:mm',
    });
});

$(function () {
    $('#datetimepicker2').datetimepicker({
        format: 'DD/MM/YYYY hh:mm',
    });
});

