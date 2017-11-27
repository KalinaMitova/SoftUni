SELECT Content, SentOn FROM Messages
WHERE SentOn > '2014-05-12' AND Content LIKE '%just%'
ORDER BY Id DESC