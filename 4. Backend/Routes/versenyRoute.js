const express = require("express");
const { getAllverseny, putVerseny } = require("../Controllers/versenyController");

const router = express.Router();

router.get("/versenyek", getAllverseny);
router.put("/versenyek/:id", putVerseny )


module.exports = router;