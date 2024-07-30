import requests
import json
import time


charge_url = "http://localhost:8000/charge"
payment_url = "http://localhost:8000/payment"

charge_data = {
    "amount": "100",
    "currency": "USD",
    "ClientEmail": "client@bank.com"
}

payment_data_template = {
    "cardNumber": "1234567890123456",
    "expirationDate": "1223",
    "holderName": "John Doe",
    "securityCode": "123",
    "amount": "100",
    "currency": "USD"
}

headers = {
    "Content-Type": "application/json"
}

transaction_ids = []
for _ in range(3):

    response = requests.post(charge_url, headers=headers, data=json.dumps(charge_data))
    if response.status_code == 200:
        transaction_ids.append(response.json().get("transactionId"))

    time.sleep(5)

# Make a payment request for each transaction ID
for transaction_id in transaction_ids:
    payment_data = payment_data_template.copy()
    payment_data["TransactionId"] = transaction_id
    response = requests.post(payment_url, headers=headers, data=json.dumps(payment_data))
    print(f"Payment request for TransactionId {transaction_id}: {response.status_code}, {response.text}")
