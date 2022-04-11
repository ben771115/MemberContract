# 需求是輸入電話號碼取得會員狀態, 合約狀態及相關資訊, 輸出的schema己提供.
### Parameter
- phone_no: phone number - this phone number will be user’s mobile phone number without country code.
So, if the user tries to log in (to the Azure B2C service that will be using this club API)
with “+886 970699044”, then the API will be called with /account-details?phone=0970699044&region=TW
### Responses
-
| phoneNumber              | string       |                                                      | The phone number of the request                                                                                                                                                                                                     |
| ------------------------ | ------------ | ---------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| region                   | string       |                                                      | The region of the request                                                                                                                                                                                                           |
| isMember                 | boolean      | true/ false                                          | true- Check member's information which not expired yet and status is normal                                                                                                                                                         |
| memberId                 | string       | member's id                                          |                                                                                                                                                                                                                                     |
| membershipExpirationTime | datetime     | membership expiration in ISO-8601 format in UTC time | This must be translated to UTC time in order for this date-time to be standardized and not force the client to translate to local time.                                                                                             |
| isCustomer               | boolean      | true/ false                                          | true- Check contract first, if this phone number relates to the contract table and contract status is normal, please make isCustomer=true (customers could have many contracts, once one of those contracts' condition established) |
| contractId               | string array | contract's id                                        | get contract's id from contract information, same condition established as above, could be more than one contract                                                                                                                   |
### Schema
- 
{
  "phoneNumber" : "0970699044",
  "region" : "TW",
  "isMember": true,
  "memberId": "D14562",
  "membershipExpirationTime": "2022-05-12T15:13:00Z",
  "isCustomer": true,
  "contracts": [
     "32923903", "238405", "230923"
  ]
}