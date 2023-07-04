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

    const disableCalc = () => { $('.calculate').attr('disabled', 'disabled'); };
    const activeCalc = () => { $('.calculate').removeAttr('disabled'); };
    $('#Age').on("change", function () {
        const age = $('#Age').val() - 0;
        const ageErrorMessage = $('.age div.error-message');
        if (age == null || isNaN(age)) {
            ageErrorMessage.text("*Введите количество полных лет.");
            ageErrorMessage.show();
            disableCalc();
        }
        else if (age <= 0 || age > 100) {
            ageErrorMessage.text("*Недопустимый возраст.");
            ageErrorMessage.show();
            disableCalc();
        }
        else {
            ageErrorMessage.hide();
            activeCalc();
        }
    });

    $('#Weight').on("change", function () {
        const weight = $('#Weight').val() - 0;
        const weightErrorMessage = $('.weight div.error-message');
        if (weight == null || isNaN(weight)) {
            weightErrorMessage.text("*Введите вес в кг.");
            weightErrorMessage.show();
            disableCalc();
        }
        else if (weight <= 0) {
            weightErrorMessage.text("*Недопустимый вес.");
            weightErrorMessage.show();
            disableCalc();
        }
        else {
            weightErrorMessage.hide();
            activeCalc();
        }
    });

    $('#Height').on("change", function () {
        const height = $('#Height').val() - 0;
        const heightErrorMessage = $('.height div.error-message');
        if (height == null || isNaN(height)) {
            heightErrorMessage.text("*Введите рост в см.");
            heightErrorMessage.show();
            disableCalc();
        }
        else if (height <= 3 || height > 250) {
            heightErrorMessage.text("*Укажите рост в см, чтобы воспользоваться калькулятором КБЖУ.");
            heightErrorMessage.show();
            disableCalc();
        }
        else {
            heightErrorMessage.hide();
            activeCalc();
        }
    });

    $('#Percent').on("change", function () {
        const percent = $('#Percent').val() - 0;
        const percentErrorMessage = $('.percent div.error-message');
        if (percent == null || isNaN(percent)) {
            percentErrorMessage.text("*Введите желаемый процент дефицита/профицита.");
            percentErrorMessage.show();
            disableCalc();
        }
        else if (percent < 0 || percent > 30) {
            percentErrorMessage.text("*С целью сохранения здоровья, процент дефицита/профицита не должен превышать 30.");
            percentErrorMessage.show();
            disableCalc();
        }
        else {
            percentErrorMessage.hide();
            activeCalc();
        }
    });

    $('#PercentOfProteins, #PercentOfFats, PercentOfCarbs').on("change", function () {
        const proteinsPercent = $('#PercentOfProteins').val() - 0;
        const fatsPercent = $('#PercentOfFats').val() - 0;
        const carbsPercent = $('#PercentOfCarbs').val() - 0;
        const proteinsErrorMessage = $('.protein-percent div.error-message');
        const fatsErrorMessage = $('.fat-percent div.error-message');
        const carbsErrorMessage = $('.carb-percent div.error-message');
        const sum = proteinsPercent + fatsPercent + carbsPercent;
        if (proteinsPercent == null || isNaN(proteinsPercent) || proteinsPercent < 0) {
            proteinsErrorMessage.text("*Введите желаемый процент белка в рационе.");
            proteinsErrorMessage.show();
            disableCalc();
        }
        else if (fatsPercent == null || isNaN(fatsPercent) || fatsPercent < 0) {
            fatsErrorMessage.text("*Введите желаемый процент жира в рационе.");
            fatsErrorMessage.show();
            disableCalc();
        }
        else if (carbsPercent == null || isNaN(carbsPercent) || carbsPercent < 0) {
            carbsErrorMessage.text("*Введите желаемый процент углеводов в рационе.");
            carbsErrorMessage.show();
            disableCalc();
        }
        else if (sum != 100) {
            $('.protein-percent div.error-message,.fat-percent div.error-message,.carb-percent div.error-message').text("*Сумма нутриентов в рациона должна равняться 100%.");
            $('.protein-percent div.error-message,.fat-percent div.error-message,.carb-percent div.error-message').show();
            disableCalc();
        }
        else {
            $('.protein-percent div.error-message,.fat-percent div.error-message,.carb-percent div.error-message').hide();
            activeCalc();
        }
    });
});