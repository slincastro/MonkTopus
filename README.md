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
    "correlationId":"1be7fbbc-b64b-4853-ba4b-9dba6046119c",
    "expirationDate": "1223",
    "holderName": "John Doe",
    "securityCode": "123",
    "amount":"100",
    "currency":"USD"
}'
```

- Activate client 

python3 -m venv myenv

source myenv/bin/activate