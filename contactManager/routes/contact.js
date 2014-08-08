//require mongoose DAL
var mongoose = require('mongoose');

//connect to our database
mongoose.connect('localhost:27017/contacts');

//declare and define db schema
var Schema = mongoose.Schema;
var ContactSchema = new Schema({
	name: { type: String, required: true},
	phone: { type: Number}
});

//create a model based on the ContactSchema
var ContactModel = mongoose.model('Contact',ContactSchema);

//method used to select * docs from contacts table
exports.index = function(req,res){
	return ContactModel.find(function(err,contacts){
		if(!err){
			res.jsonp(contacts);
		}else{
			console.log(err);
		}
	});
}

//method that gets only 1 recod based on index

exports.findById = function(req,res){
	return ContactModel.findById(req.params.id,
		function(err,contact){
		if(!err){
			res.jsonp(contact);
		}else{
			console.log(err);
		}
	});
}

//insert contact method
exports.addContact = function(req,res){
	var contact = new ContactModel({
		name: req.body.name,
		phone: req.body.phone
	});
	contact.save(function(err){
		if(!err){
			console.log('contact created');
		}else{
			console.log(err);
		}
	});
	return res.send(contact);
}

//update document example
exports.updateContact = function(req, res){
	return ContactModel.findById(req.params.id,function(err,contact){
		contact.name = req.body.name;
		contact.phone = req.body.phone;
		contact.save(function(err){
			if(!err){
				console.log('contact updated!');
			}else{
				console.log('contact update error: ' + err);
			}
			res.send(contact);
		});
	});
}

//delete document example
exports.deleteContact = function(req, res){
	return ContactModel.findById(req.params.id,function(err,contact){
		contact.remove(function(err){
			if(!err){
				console.log('contact removed');

			}else{
				console.log('contact delete error' + err);

			}
		});
		
		res.send();
	});
}