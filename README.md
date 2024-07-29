# MonkTopus

- Ejecutar:
`docker-compose up`

- Crear una peticion de cobro:

```
curl --request POST \
  --url http://localhost:8000/charge \
  --header "Content-Type: application/json" \
  --data '{
    "amount":"100",
    "currency":"USD",
    "ClientEmail":"client@bank.com"
}'
```

- lanzar una peticion de pago:

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

