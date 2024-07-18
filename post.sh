curl -X POST http://localhost:8000/payment \
-H "Content-Type: application/json" \
-d '{
    "cardNumber": "1234567890123456",
    "expirationMonth": "12",
    "expirationYear": "2023",
    "holderName": "John Doe",
    "securityCode": "123"
}'
