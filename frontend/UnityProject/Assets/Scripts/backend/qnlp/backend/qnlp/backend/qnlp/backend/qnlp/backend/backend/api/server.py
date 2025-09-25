from flask import Flask, request, jsonify
from qnlp.emotion_analyzer import quantumEmotionAnalyzer

app = Flask(__name__)

@app.route('/analyze_emotion', methods=['POST'])
def analyze_emotion():
    data = request.get_json()
    user_tone = data.get('tone', 'neutral')
    context = data.get('context', 'conversation')
    reaction, score = quantumEmotionAnalyzer(user_tone, context)
    return jsonify({'reaction': reaction, 'score': float(score)})

if __name__ == '__main__':
    app.run(debug=True, host='0.0.0.0', port=5000)
