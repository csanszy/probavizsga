const express = require("express");
const { getAlldiak, postDiak } = require("../Controllers/diakController");

const router = express.Router();

router.get("/diak", getAlldiak);
router.post("/diak", postDiak )


module.exports = router;