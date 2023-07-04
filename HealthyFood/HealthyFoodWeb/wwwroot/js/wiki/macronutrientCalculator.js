$(document).ready(function () {

    $('.calculate').click(function () {
        const sex = $('input[name="Sex"][type="radio"]:checked').val();
        const goal = $('input[name="Goal"][type="radio"]:checked').val();
        const age = $('#Age').val();
        const weight = $('#Weight').val();
        const height = $('#Height').val();
        const percent = $('#Percent').val();
        const activityRatio = $("#ActivityRatio option:selected").val();
        const proteinsPercent = $('#PercentOfProteins').val();
        const fatsPercent = $('#PercentOfFats').val();
        const carbsPercent = $('#PercentOfCarbs').val();
        const url = `/api/wiki/CaloriesCalculation?age=${age}&weight=${weight}&height=${height}&percent=${percent}&sex=${sex}&goal=${goal}&activityRatio=${activityRatio}&proteinsPercent=${proteinsPercent}&fatsPercent=${fatsPercent}&carbsPercent=${carbsPercent}`;
        $.get(url)
            .then(function (dataObj) {
                console.log(dataObj);
                $('.preview').hide();
                $('.parent').show();
                $('.ansHB').text(dataObj.harrisBenedictAns);
                $('.ansMSJ').text(dataObj.mifflinStJeorAns);
                $('.ansWHO').text(dataObj.whoAns);
                $('.ansAverage').text(dataObj.averageAns);
                $('.ansProteins').text(dataObj.gramsOfProteins);
                $('.ansFats').text(dataObj.gramsOfFats);
                $('.ansCarbs').text(dataObj.gramsOfCarbs);
                $('.have-to-block').removeAttr('disabled');
            });
        $('.have-to-block').attr('disabled', 'disabled');
    });

    //const button_disabled = $('.calculate').attr('disabled', 'disabled');
    //const button_active = $('.calculate').removeAttr('disabled');
    $('#Age').on("change", function () {
        const age = $('#Age').val() - 0;
        if (age == null || age == NaN) {
            $('.age div.error-message').text("*Введите количество полных лет.");
            $('.age div.error-message').show();
            $('.calculate').attr('disabled', 'disabled');
        }
        if (age <= 0 || age > 100) {
            $('.age div.error-message').text("*Недопустимый возраст.");
            $('.age div.error-message').show();
            $('.calculate').attr('disabled', 'disabled');
        }
        else {
            $('.age div.error-message').hide();
            $('.calculate').removeAttr('disabled');
        }
    });

    $('#Weight').on("change", function () {
        const weight = $('#Weight').val() - 0;
        if (weight == null || weight == NaN) {
            $('.weight div.error-message').text("*Введите вес в кг.");
            $('.weight div.error-message').show();
            $('.calculate').attr('disabled', 'disabled');
        }
        if (weight <= 0) {
            $('.weight div.error-message').text("*Недопустимый вес.");
            $('.weight div.error-message').show();
            $('.calculate').attr('disabled', 'disabled');
        }
        else {
            $('.weight div.error-message').hide();
            $('.calculate').removeAttr('disabled');
        }
    });

    $('#Height').on("change", function () {
        const height = $('#Height').val() - 0;
        if (height == null || height == NaN) {
            $('.height div.error-message').text("*Введите рост в см.");
            $('.height div.error-message').show();
            $('.calculate').attr('disabled', 'disabled');
        }
        if (height <= 3 || height > 250) {
            $('.height div.error-message').text("*Укажите рост в см, чтобы воспользоваться калькулятором КБЖУ.");
            $('.height div.error-message').show();
            $('.calculate').attr('disabled', 'disabled');
        }
        else {
            $('.height div.error-message').hide();
            $('.calculate').removeAttr('disabled');
        }
    });

    $('#Percent').on("change", function () {
        const percent = $('#Percent').val() - 0;
        if (percent == null || percent == NaN) {
            $('.percent div.error-message').text("*Введите желаемый процент дефицита/профицита.");
            $('.percent div.error-message').show();
            $('.calculate').attr('disabled', 'disabled');
        }
        if (percent < 0 || percent > 30) {
            $('.percent div.error-message').text("*С целью сохранения здоровья, процент дефицита/профицита не должен превышать 30.");
            $('.percent div.error-message').show();
            $('.calculate').attr('disabled', 'disabled');
        }
        else {
            $('.percent div.error-message').hide();
            $('.calculate').removeAttr('disabled');
        }
    });

    $('#PercentOfProteins, #PercentOfFats, PercentOfCarbs').on("change", function () {
        const proteinsPercent = $('#PercentOfProteins').val() - 0;
        const fatsPercent = $('#PercentOfFats').val() - 0;
        const carbsPercent = $('#PercentOfCarbs').val() - 0;
        const sum = proteinsPercent + fatsPercent + carbsPercent;
        if (proteinsPercent == null || proteinsPercent == NaN || proteinsPercent < 0) {
            $('.protein-percent div.error-message').text("*Введите желаемый процент белка в рационе.");
            $('.protein-percent div.error-message').show();
            $('.calculate').attr('disabled', 'disabled');
        }
        if (fatsPercent == null || fatsPercent == NaN || fatsPercent < 0) {
            $('.fat-percent div.error-message').text("*Введите желаемый процент жира в рационе.");
            $('.fat-percent div.error-message').show();
            $('.calculate').attr('disabled', 'disabled');
        }
        if (carbsPercent == null || carbsPercent == NaN || carbsPercent < 0) {
            $('.carb-percent div.error-message').text("*Введите желаемый процент углеводов в рационе.");
            $('.carb-percent div.error-message').show();
            $('.calculate').attr('disabled', 'disabled');
        }
        if (sum > 100) {
            $('.protein-percent div.error-message,.fat-percent div.error-message,.carb-percent div.error-message').text("*Сумма нутриентов в рациона не должна превышать 100%.");
            $('.protein-percent div.error-message,.fat-percent div.error-message,.carb-percent div.error-message').show();
            $('.calculate').attr('disabled', 'disabled');
        }
        else {
            $('.protein-percent div.error-message,.fat-percent div.error-message,.carb-percent div.error-message').hide();
            $('.calculate').removeAttr('disabled');
        }
    });
});