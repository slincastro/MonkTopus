# MonkTopus

- Ejecutar:
`docker-compose up`

- lanzar una peticion:

```
curl --request POST \
  --url http://localhost:8000/payment \
  --header "Content-Type: application/json" \
  --data '{
    "cardNumber": "1234567890123456",
    "expirationDate": "1223",
    "holderName": "John Doe",
    "securityCode": "123",
    "amount":"100",
    "currency":"USD"
}'
```

