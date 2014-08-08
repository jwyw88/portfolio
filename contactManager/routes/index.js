var express = require('express');
var router = express.Router();
var contacts = require('./contact');

//root index page shows list of all contacts
router.get('/',contacts.index);
//same as index above but shows if someone call contacts page
router.get('/contacts',contacts.index);
//get a and show 1 contact by its id
router.get('/contacts/:id',contacts.findById); 
//post method for inserting a new contact
router.post('/contacts',contacts.addContact);
//put method for updating a contact
router.put('/contacts/:id', contacts.updateContact);
//delete method for removing a contact
router.delete('/contacts/:id', contacts.deleteContact);

module.exports = router;