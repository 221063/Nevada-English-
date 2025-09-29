from functools import wraps
from flask import request, jsonify
from .config import Secrets

def require_api_key(f):
    @wraps(f)
    def decorated_function(*args, **kwargs):
        api_key = request.headers.get('X-API-Key')
        if api_key != Secrets.TEST_KEY:
            return jsonify({'error': 'Clave API inválida'}), 401
        return f(*args, **kwargs)
    return decorated_function
