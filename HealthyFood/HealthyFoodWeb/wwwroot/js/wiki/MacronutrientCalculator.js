$().ready(function () {
    $(".basic-form").validate(
        {
            rules:
            {
                Age: {
                    required: true,
                    number: true,
                    digits: true,
                    range: [14, 120]
                },
                Weight: {
                    required: true,
                    number: true,
                    min: 30,
                },
                Height: {
                    required: true,
                    number: true,
                    range: [5, 250],
                },
                Percent: {
                    required: true,
                    number: true,
                    digits: true,
                    range: [0, 30],
                },
                PercentOfProteins: {
                    required: true,
                    number: true,
                    digits: true,
                    min: 0,
                },
                PercentOfFats: {
                    required: true,
                    number: true,
                    digits: true,
                    min: 0,
                },
                PercentOfCarbs: {
                    required: true,
                    number: true,
                    digits: true,
                    min: 0,
                },
            },
            messages:
            {
                Sex: {
                    required: "Пожалуйста, выберите Ваш пол"
                },
                Goal: {
                    required: "Пожалуйства, выберите Вашу цель<br/>"
                },
                Age: {
                    required: "Пожалуйства, введите количество Ваших полных лет",
                    number: "Пожалуйства, укажите численно сколько Вам полных лет",
                    range: "Вам должно быть больше 14 лет, чтобы воспользоваться калькулятором КБЖУ"
                },
                Weight: {
                    required: "Пожалуйства, введите Ваш вес в кг",
                    number: "Пожалуйства, укажите численно Ваш вес в кг",
                    range: "Вы должны весить больше 30 кг, чтобы воспользоваться калькулятором КБЖУ"
                },
                Height: {
                    required: "Пожалуйства, введите Ваш рост в см",
                    number: "Пожалуйства, укажите численно Ваш рост в см",
                    range: "Пожалуйства, укажите Ваш рост в см, чтобы воспользоваться калькулятором КБЖУ"
                },
                Percent: {
                    required: "Пожалуйства, введите желаемый Вами процент дефицита/профицита",
                    number: "Пожалуйства, укажите численно процент дефицита/профицита",
                    range: "Для осуществления ваших целей с соблюдением здорового подхода, процент дефицита/профицита не должен превышать 30"
                },
                PercentOfProteins: {
                    required: "Пожалуйства, введите желаемый Вами процент белка в рационе",
                    number: "Пожалуйства, укажите численно процент белка в рационе",
                },
                PercentOfFats: {
                    required: "Пожалуйства, введите желаемый Вами процент жира в рационе",
                    number: "Пожалуйства, укажите численно процент жира в рационе",
                },
                PercentOfCarbs: {
                    required: "Пожалуйства, введите желаемый Вами процент жира в рационе",
                    number: "Пожалуйства, укажите численно процент жира в рационе",
                },
            },
        })
);
