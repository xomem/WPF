﻿--SELECT К.Id, К.[Номер кабинета], К.[Номер отдела] as idОтдела, О.[Название отдела] as НазваниеОтдела FROM Кабинеты as К JOIN Отделы as О on О.Id = К.[Номер отдела] WHERE О.Id = 1
INSERT INTO [Сотрудники] (Имя, Фамилия, Отчетсво, [Дата рождения], Должость, Отдел, Город, Адрес, Телефон) VALUES(@Имя, @Фамилия, @Отчетсво, @Дата , @Должость, @Отдел, @Город, @Адрес, @Телефон);
