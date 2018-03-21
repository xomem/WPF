﻿SELECT c.Имя, c.Фамилия, c.Отчество, c.[Дата рождения], c.Город, c.Адрес, c.Телефон, o.[Название отдела], d.[Название должности], r.[Номер кабинета] FROM[Сотрудники] AS c INNER JOIN Отделы AS o ON c.Отдел = o.Id INNER JOIN Должности AS d ON c.Должность = d.Id INNER JOIN Кабинеты AS r ON c.Кабинет = r.Id WHERE r.[Номер кабинета] = '1'