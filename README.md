# devops_kt2
перед запуском команд для докера убедитесь что вы находить в корневой дериктории проекта

<img width="1232" height="152" alt="image" src="https://github.com/user-attachments/assets/49ed8ba7-afe5-4ae8-aa29-969b93c29d7e" />

docker build -t bookstore .
<img width="1310" height="634" alt="image" src="https://github.com/user-attachments/assets/642b5ce4-15d5-4202-b412-130aa0981a0e" />




docker run -d -p 8080:8080 -p 8081:8081 --name kt2 bookstore

<img width="1103" height="100" alt="image" src="https://github.com/user-attachments/assets/da89baba-30a7-480e-80e5-671a7b5b7c4e" />


после этого проверьте работу контейнера

docker ps

<img width="1514" height="85" alt="image" src="https://github.com/user-attachments/assets/0f6b46f6-a6e3-4426-b1ab-5aeaf88eb8ad" />






после всего этого проверяем работу api
get запросы 
curl.exe -X GET http://localhost:8080/bookstore/books/all

curl.exe -X GET http://localhost:8080/bookstore/books/search/name/Название1

curl.exe -X GET http://localhost:8080/bookstore/books/search/price/1000

curl.exe -X GET http://localhost:8080/bookstore/books/search/author/Автор3

<img width="1901" height="251" alt="image" src="https://github.com/user-attachments/assets/416b8497-d7a9-4d7d-aea1-3877c12773b9" />




