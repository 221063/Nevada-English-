import sqlite3

class Database:
    def __init__(self, db_name="nevada_english.db"):
        self.db_name = db_name
        self.create_table()

    def create_table(self):
        with sqlite3.connect(self.db_name) as conn:
            cursor = conn.cursor()
            cursor.execute('''
                CREATE TABLE IF NOT EXISTS emotion_logs (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    tone TEXT NOT NULL,
                    context TEXT NOT NULL,
                    confidence REAL,
                    timestamp DATETIME DEFAULT CURRENT_TIMESTAMP
                )
            ''')
            conn.commit()

    def save_emotion(self, tone, context, confidence):
        with sqlite3.connect(self.db_name) as conn:
            cursor = conn.cursor()
            cursor.execute('''
                INSERT INTO emotion_logs (tone, context, confidence)
                VALUES (?, ?, ?)
            ''', (tone, context, confidence))
            conn.commit()
            return cursor.lastrowid

    def get_all_emotions(self):
        with sqlite3.connect(self.db_name) as conn:
            cursor = conn.cursor()
            cursor.execute('SELECT * FROM emotion_logs')
            return cursor.fetchall()
