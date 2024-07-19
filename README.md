# MonkTopus

- Ejecutar:
`docker-compose up`

- lanzar una peticion:

```
curl --request POST \
  --url http://localhost:8000/payment \
  --data '{
    "cardNumber": "1234567890123456",
    "expirationMonth": "12",
    "expirationYear": "2023",
    "holderName": "John Doe",
    "securityCode": "123"
}'
```