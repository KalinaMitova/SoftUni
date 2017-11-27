SELECT * FROM Chats
SELECT * FROM Messages

UPDATE Chats
SET StartDate = m.SentOn
FROM Chats as c
JOIN Messages as m
on m.ChatId = c.Id
WHERE StartDate > SentOn