$(document).ready(function() {
    $("#voteBtn").click(function () {
        var checkedRadio = $("input[type=radio][name=answer]:checked")[0];
        var voice = {
            answer: checkedRadio.value
        }

        $.ajax({
            type: "POST",
            url: "/Articles/MakeVote",
            data: voice,
            success: function(isOk) {
                if (isOk) {
                    
                } else {
                    alert("Error during vote. Try to reload the page");
                }
            },
            error: function() {
                alert("Error during vote. Try to reload the page");
            }
        });
    });
});