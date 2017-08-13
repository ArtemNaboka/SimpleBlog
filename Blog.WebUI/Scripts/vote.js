$(document).ready(function() {
    $("#voteBtn").click(function () {
        var checkedRadio = $("input[type=radio][name=answer]:checked")[0];
        var voice = {
            answer: checkedRadio.value
        }

        $.ajax({
            type: "POST",
            url: "/Articles/MakeVoteAjax",
            data: voice,
            success: function(data) {
                $("#voteDiv").replaceWith(data);
            },
            error: function() {
                alert("Error during vote. Try to reload the page");
            }
        });
    });
});