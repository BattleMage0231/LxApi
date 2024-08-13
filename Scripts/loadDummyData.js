const dummyData = require('./Scripts/dummyData.json')

const entries = db.getCollection('Entries')

entries.deleteMany({})

entries.insertMany(dummyData)

entries.find().forEach(printjson);
