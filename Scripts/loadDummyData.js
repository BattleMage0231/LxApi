const dummyData = require('./Scripts/dummyData.json')

const entries = db.getCollection('Entries')

entries.deleteMany({})
entries.dropIndexes()

entries.createIndex({
    _t: 1,
    Key: 1,
    NormalizedKey: 1
})
entries.insertMany(dummyData)

entries.find().forEach(printjson)
