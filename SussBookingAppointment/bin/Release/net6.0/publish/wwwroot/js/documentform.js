$(document).ready(function () {
  $("#document-form").submit(function (e) {
    if (!CheckValidation()) {
          e.preventDefault();
      }
      return true;
  });

  function CheckValidation() {
    var isValid = false;
    isValid = $('#document-form').validate().element($('#SelectedCourse,#SelectedCourseDesc'));
    isValid = ($('#document-form').validate().element($('#SelectedDocumentFormat'))) ? isValid : false;
    isValid = ($('#document-form').validate().element($('#Yearofstudy'))) ? isValid : false;
    isValid = ($('#document-form').validate().element($('#DocumentCopies'))) ? isValid : false;
    if (isValid && $("#SelectedDocument").val() == "Testamur" && ($("#dnd-default-msg").val() == '' || $("#dnd-default-msg").val() == undefined)) {
      $('#myModal').show();
      isValid = false;
    }
    return isValid;
  }
});
