﻿using Data.Interface.Models;
using HealthyFoodWeb.FakeDbModels;

namespace HealthyFoodWeb.Services.FakeDb
{
    public class WikiRepositoryBAA : IWikiRepositoryBAA
    {
        public static List<IBlockModelBAA> Titles =
            new List<IBlockModelBAA>() {
                new BlockModelBAA
                {
                   Title = "Биологически активные добавки(БАД)",
                }, 
                new BlockModelBAA
                {
                   Title = "БАД(биологически активные добавки)",
                   Text = "В данной статье вы узнаете, что такое БАДы. Польза биологически активных добавок в питании, состав и содержание натуральных веществ. Подробности на сайте. БАДы появились 100 лет назад. Первую в мире люцерновую добавку к пище создал американский химик Карл Ренборг. Сегодня применение биодобавок стало обычным делом, а с приходом пандемии спрос на них вырос в десятки раз. Витамины и БАД принимают для профилактики, во время разных болезней, в периоды восстановления. В Россию БАДы пришли в конце прошлого века. Сегодня практически в каждой домашней аптечке можно найти баночки с биодобавками. Их рассматривают как альтернативу средствам народной медицины. Биодобавками люди пытаются лечиться, но не всегда выбирают правильную комбинацию компонентов. Что такое БАДы, как их правильно принимать — читайте в нашей статье."
                },
                new BlockModelBAA
                {
                    Title = "Что такое БАДы?",
                    Text="БАД — биологически активная добавка, дополнение к пище. Полезные вещества поступают вместе с едой, однако компенсировать все потребности одними продуктами сложно. При хроническом недостатке витаминов, микроэлементов, макроэлементов, биосорбентов, микронутриентов нарушается гомеостаз, а вместе с ним — работа отдельных органов и систем. Кроме того, существуют вещества, которые организм не может вырабатывать, но остро в них нуждается. Биологически активные добавки — это источник веществ для восполнения потенциального пищевого дефицита. Дополняя свой рацион БАД, можно восстановить и поддержать некоторые функции организма. По данным научных исследований, регулярное применение биодобавок снижает риск развития дефицитных состояний на 80%."
                },
                new BlockModelBAA
                {
                    Title = "Виды добавок",
                    Text="Биологически активные добавки делят по составу и направленному действию на три большие группы — нутрицевтики, парафармацевтики, эубиотики.К нутрицевтикам относят витамины и витаминоподобные средства — предшественники витаминов, аминокислот, макро и микроэлементов, полиненасыщенных жирных кислот, углеводов (моносахаридов и дисахаридов), клетчатки, некоторые ферментов. Их действие направлено на профилактику болезней, торможение старения организма, увеличение продолжительности жизни, поддержание работоспособности органов и систем, общее улучшение состояния здоровья. Нутрицевтики работают по принципу накопительного эффекта. Для достижения результата биоактивное средство нужно пит длительное время. Однако после окончания приема их концентрация в организме сохраняется еще дольше."
                },
                new BlockModelBAA
                {
                    Title = "Как подобрать биологически активную добавку?",
                    Text="Выбор средства зависит от области применения. Сегодня можно найти биологически активные добавки на все случаи жизни. Весной и осенью, когда организму нужна помощь, чтобы противостоять сезонным инфекциям, можно использовать БАДы для повышения иммунитета. Если же избежать болезни не удалось, быстрее выздороветь помогут БАДы при простуде. Перед тем, как принимать биодобавку вместе с лекарствами, нужно проконсультироваться с врачом. БАД может ускорить выведение препарата или ухудшить (замедлить) его всасывание, что чревато снижением лечебного эффекта."
                },
                new BlockModelBAA
                {
                    Title = "Дозировка",
                    Text="Каждую упаковку сопровождает инструкция с указанием дозировки. Взрослому человеку достаточно 1-2 капсул (таблеток) в день. Пить желательно в одно и то же время, чтобы сохранять постоянную концентрацию активного вещества в крови. Принимать добавку до еды или после — зависит от состава. Некоторые БАДы выпускаются в форме капель. Также есть детские варианты биодобавок в виде жевательных конфет."
                },
            };

        public List<IBlockModelBAA> GetTitles()
        {
            return Titles;
        }

    }
}
