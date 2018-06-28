$(() => {


    $("#confirm").on('click', function () {
        updateStatus(1);
    });


    $("#refuse").on('click', function () {
        updateStatus(2);
    });


    function updateStatus(status) {
        const id = $("#candidateId").val();
        $("#buttons button").prop('disabled', true);
        $.post('/Home/UpdateStatus', { id, status }, () => {
            $.get('/Home/GetCounts', counts => {
                $("#pendingCount").text(counts.Pending);
                $("#confirmedCount").text(counts.Confirmed);
                $("#refusedCount").text(counts.Refused);
                $("button").hide();
            });
        });
    }


    $("#toggle").on('click', function () {
        $("td:nth-child(5), th:nth-child(5)").toggle();
    });

});