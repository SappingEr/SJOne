
$(document).ready(function () {

        function refreshFilter(filterLink) {
            $.ajax({
                async: true,
                type: 'GET',
                url: '@Url.Action("StartList")/@Model.Id' + filterLink,
                success: function (data) {
                    $('#mainList').html(data);
                }
            });
        }

            $('#gender').change(function () {
                var gender = $(this).val();
                if (gender !== "0") {
        $('#ageGroup').prop('selectedIndex', 0);
    var filterLink = '?gender=' + gender;
    refreshFilter(filterLink);
}
                else {
        refreshFilter(filterLink = "");
    }
});

            $('#ageGroup').change(function () {
                var ageGroup = $(this).val();
    $('#gender').val(0);
    var filterLink = '?ageGroupId=' + ageGroup;
    refreshFilter(filterLink);
});

            $('#judge').change(function () {
                var judgeId = $(this).val();
                $.ajax({
        type: 'GET',
    url: '@Url.Action("JudgeAssistantStartList")/' + @Model.Id + '?judgeId=' + judgeId,
                    success: function (data) {
        $('#assistantList').html(data);
    }
});
})

            function refreshPage(pageLink) {
            var ageGroup = $('#ageGroup').val();
    var gender = $('#gender').val();

            if (ageGroup !== '') {
                var link = pageLink + '&ageGroupId=' + ageGroup;
}
            else if (gender !== '0') {
                var link = pageLink + '&gender=' + gender;
}
else
    var link = pageLink;

                $.ajax({
        async: true,
    type: 'GET',
    url: link,
                    success: function (data) {
        $('#mainList').html(data);
    }
});
}

            $(document).on('click', '#nPage', function() {
                var setFirst = $(this).val();
    var pageLink = '@Url.Action("StartList")/@Model.Id' + '?setFirst=' + setFirst;
    refreshPage(pageLink);
});

            $(document).on('click', '#pPage', function () {
                var preItem = $(this).val();
    var pageLink = '@Url.Action("StartList")/@Model.Id' + '?setFirst=' + preItem;
    refreshPage(pageLink);
});

            function refreshMainList() {
                var setFirst = $('#nowPage').val() - 1;
    var pageLink = '@Url.Action("StartList")/@Model.Id' + '?setFirst=' + setFirst;
    refreshPage(pageLink);
}

            function refreshAssistList(judge) {
        $.ajax({
            async: true,
            type: 'GET',
            url: '@Url.Action("JudgeAssistantStartList")/@Model.Id' + '?judgeId=' + judge,
            success: function (data) {
                $('#assistantList').html(data);
            }
        });
    }

            $(document).on('click', '.addToAssist', function () {
                var numId = $(this).attr('id');
    var judge = $('#judge').val();
                $.ajax({
        type: 'POST',
    dataType: 'json',
                    data: {id: @Model.Id, startNumberId: numId, judgeId: judge},
    url: '@Url.Action("AddToJudgeAssist", "Judge")',
                    success: function () {
        refreshMainList();
    refreshAssistList(judge);
},
                    error: function (response) {
        alert(response.responseText);
    }
});
});

            $(document).on('click', '.addToMain', function () {
                var numId = $(this).attr('id');
    var judge = $('#judge').val();
                $.ajax({
        type: 'POST',
    dataType: 'json',
                    data: {id: @Model.Id, startNumberId: numId},
    url: '@Url.Action("AddToMainJudge", "Judge")',
                    success: function () {
        refreshMainList();
    refreshAssistList(judge);
},
                    error: function (response) {
        alert(response.responseText);
    }
});

});

            $(document).on('click', '#clearFilter', function () {
        $('#gender').val(0);
    $('#ageGroup').prop('selectedIndex', 0);
    refreshMainList();
});            
        });